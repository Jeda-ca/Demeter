using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ENTITY;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace GUI.Helpers
{
    public class ReportePdfExporter
    {
        // Colores Personalizados Demeter (Ejemplos, puedes ajustarlos)
        private readonly string colorPrimarioDemeter = "#2E7D32"; // Un verde oscuro
        private readonly string colorSecundarioDemeter = "#A1887F"; // Un tono tierra/marrón claro
        private readonly string colorAcentoDemeter = "#FF8F00"; // Un naranja/ámbar para acentos
        private readonly string colorTextoTitulos = "#1B5E20"; // Verde muy oscuro para títulos
        private readonly string colorTextoGeneral = Colors.Grey.Darken3; // Para texto normal
        private readonly string colorFondoCabeceraTabla = Colors.Grey.Lighten3; // Un gris muy claro para cabeceras de tabla
        private readonly string colorBordeTabla = Colors.Grey.Lighten2;


        public ReportePdfExporter()
        {
        }

        public void GenerarReporteVentasPdf(IEnumerable<Venta> ventas, string nombreAdministrador, string reporteId, string tituloReporte, string infoAdicionalHeader = null)
        {
            if (ventas == null || !ventas.Any())
            {
                MessageBox.Show("No hay datos de ventas para generar el reporte.", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar Reporte PDF";
                saveFileDialog.FileName = $"Reporte_{tituloReporte.Replace(" ", "_")}_{reporteId}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    {
                        try
                        {
                            var document = Document.Create(container =>
                            {
                                container.Page(page =>
                                {
                                    page.Margin(35f, Unit.Point);
                                    page.Size(PageSizes.Letter);
                                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Calibri).FontColor(colorTextoGeneral));
                                    page.Header().Element(headerContainer => ComposeHeader(headerContainer, nombreAdministrador, reporteId, tituloReporte, infoAdicionalHeader));
                                    page.Content().Element(contentContainer => ComposeVentasTable(contentContainer, ventas));
                                    page.Footer().AlignCenter().Text(text =>
                                    {
                                        var footerStyle = TextStyle.Default.FontSize(8f);
                                        text.CurrentPageNumber().Style(footerStyle);
                                        text.Span(" / ").Style(footerStyle);
                                        text.TotalPages().Style(footerStyle);
                                    });
                                });
                            });
                            document.GeneratePdf(saveFileDialog.FileName);
                            MessageBox.Show($"Reporte guardado exitosamente en:\n{saveFileDialog.FileName}", "Reporte Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void ComposeHeader(IContainer container, string nombreAdministrador, string reporteId, string tituloReporte, string infoAdicional = null)
        {
            var titleStyle = TextStyle.Default.FontSize(18).Bold().FontColor(colorTextoTitulos);
            var subTitleStyle = TextStyle.Default.FontSize(14).SemiBold().FontColor(colorPrimarioDemeter);
            var detailStyle = TextStyle.Default.FontSize(9).FontColor(Colors.Grey.Darken1);
            var additionalInfoStyle = TextStyle.Default.FontSize(10).Italic().FontColor(colorSecundarioDemeter);

            container.Row(row =>
            {
                row.RelativeItem(1).Column(column =>
                {
                    var logoStream = typeof(ReportePdfExporter).Assembly.GetManifestResourceStream("GUI.image.LogoDemeter_ORIGINAL.png");
                    if (logoStream != null)
                    {
                        using (var ms = new MemoryStream())
                        {
                            logoStream.CopyTo(ms);
                            byte[] logoBytes = ms.ToArray();
                            column.Item().Width(80f, Unit.Point).Image(logoBytes);
                        }
                    }
                    else
                    {
                        column.Item().Text("Logo no encontrado").Style(detailStyle.FontColor(Colors.Red.Medium));
                    }
                });

                row.RelativeItem(3).PaddingLeft(10f).Column(column =>
                {
                    column.Item().AlignCenter().Text("Demeter").Style(titleStyle);
                    column.Item().AlignCenter().Text(tituloReporte).Style(subTitleStyle);
                    if (!string.IsNullOrWhiteSpace(infoAdicional))
                    {
                        column.Item().AlignCenter().Text(infoAdicional).Style(additionalInfoStyle);
                    }
                    column.Spacing(6f);

                    column.Item().Text(text =>
                    {
                        text.Span("ID Reporte: ").SemiBold().Style(detailStyle);
                        text.Span(reporteId).Style(detailStyle);
                    });
                    column.Item().Text(text =>
                    {
                        text.Span("Generado por: ").SemiBold().Style(detailStyle);
                        text.Span(nombreAdministrador).Style(detailStyle);
                    });
                    column.Item().Text(text =>
                    {
                        text.Span("Fecha de Generación: ").SemiBold().Style(detailStyle);
                        text.Span(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")).Style(detailStyle);
                    });
                });
            });
            container.PaddingBottom(12f);
            container.LineHorizontal(1f).LineColor(colorSecundarioDemeter);
            container.PaddingBottom(12f);
        }

        private void ComposeVentasTable(IContainer container, IEnumerable<Venta> ventas)
        {
            IContainer CellStyleHeader(IContainer c) => c.BorderBottom(1.5f).BorderColor(colorPrimarioDemeter).Padding(6f).Background(colorFondoCabeceraTabla);
            IContainer CellStyleData(IContainer c, bool isEvenRow) => c.BorderBottom(1f).BorderColor(colorBordeTabla).Padding(6f).Background(isEvenRow ? Colors.White : Colors.Grey.Lighten4);

            int rowIndex = 0;
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(40f);
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(2.5f);
                    columns.RelativeColumn(2f);
                    columns.RelativeColumn(1.2f);
                    columns.RelativeColumn(1.2f);
                    columns.RelativeColumn(1.2f);
                    columns.RelativeColumn(1.5f);
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("ID").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Fecha").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Cliente").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Vendedor").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).AlignRight().Text(text => text.Span("Subtotal").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).AlignRight().Text(text => text.Span("Descuento").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).AlignRight().Text(text => text.Span("Total").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Estado").SemiBold().FontColor(colorTextoTitulos));
                });

                foreach (var venta in ventas)
                {
                    bool isEven = rowIndex % 2 == 0;
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(venta.IdVenta.ToString());
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(venta.FechaOcurrencia.ToString("dd/MM/yyyy"));
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text($"{venta.Cliente?.Nombre} {venta.Cliente?.Apellido}");
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(venta.Vendedor?.CodigoVendedor);
                    table.Cell().Element(c => CellStyleData(c, isEven)).AlignRight().Text(venta.Subtotal.ToString("C"));
                    table.Cell().Element(c => CellStyleData(c, isEven)).AlignRight().Text(venta.Descuento.ToString("C"));
                    table.Cell().Element(c => CellStyleData(c, isEven)).AlignRight().Text(venta.Total.ToString("C"));
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(venta.EstadoVenta?.Nombre);
                    rowIndex++;
                }
            });
        }

        public void GenerarReporteInventarioPdf(IEnumerable<Producto> productos, string nombreAdministrador, string reporteId, string tituloReporte, string infoAdicionalHeader = null)
        {
            if (productos == null || !productos.Any())
            {
                MessageBox.Show("No hay datos de inventario para generar el reporte.", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar Reporte de Inventario PDF";
                saveFileDialog.FileName = $"Reporte_{tituloReporte.Replace(" ", "_")}_{reporteId}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    {
                        try
                        {
                            Document.Create(container =>
                            {
                                container.Page(page =>
                                {
                                    page.Margin(30f, Unit.Point);
                                    page.Size(PageSizes.Letter);
                                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Calibri).FontColor(colorTextoGeneral));
                                    page.Header().Element(headerContainer => ComposeHeader(headerContainer, nombreAdministrador, reporteId, tituloReporte, infoAdicionalHeader));
                                    page.Content().Element(contentContainer => ComposeInventarioTable(contentContainer, productos, tituloReporte.Contains("General")));
                                    page.Footer().AlignCenter().Text(text =>
                                    {
                                        var footerStyle = TextStyle.Default.FontSize(8f);
                                        text.CurrentPageNumber().Style(footerStyle);
                                        text.Span(" / ").Style(footerStyle);
                                        text.TotalPages().Style(footerStyle);
                                    });
                                });
                            }).GeneratePdf(saveFileDialog.FileName);
                            MessageBox.Show($"Reporte de inventario guardado exitosamente en:\n{saveFileDialog.FileName}", "Reporte Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { MessageBox.Show($"Error al generar el PDF de inventario: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void ComposeInventarioTable(IContainer container, IEnumerable<Producto> productos, bool esReporteGeneral)
        {
            IContainer CellStyleHeader(IContainer c) => c.BorderBottom(1.5f).BorderColor(colorPrimarioDemeter).Padding(6f).Background(colorFondoCabeceraTabla);
            IContainer CellStyleData(IContainer c, bool isEvenRow) => c.BorderBottom(1f).BorderColor(colorBordeTabla).Padding(6f).Background(isEvenRow ? Colors.White : Colors.Grey.Lighten4);

            int rowIndex = 0;
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3f);
                    columns.RelativeColumn(2f);
                    columns.RelativeColumn(1.5f);
                    columns.ConstantColumn(60f);
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(2f);
                    if (esReporteGeneral)
                    {
                        columns.RelativeColumn(1.5f);
                    }
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Producto").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Categoría").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Unidad").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).AlignRight().Text(text => text.Span("Stock").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).AlignRight().Text(text => text.Span("Precio").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Últ. Modif.").SemiBold().FontColor(colorTextoTitulos));
                    if (esReporteGeneral)
                    {
                        header.Cell().Element(CellStyleHeader).Text(text => text.Span("Vendedor").SemiBold().FontColor(colorTextoTitulos));
                    }
                });

                foreach (var producto in productos)
                {
                    bool isEven = rowIndex % 2 == 0;
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(producto.Nombre);
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(producto.Categoria?.Nombre);
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(producto.UnidadMedida?.Nombre);
                    table.Cell().Element(c => CellStyleData(c, isEven)).AlignRight().Text(producto.Stock.ToString());
                    table.Cell().Element(c => CellStyleData(c, isEven)).AlignRight().Text(producto.Precio.ToString("C"));
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(producto.FechaActualizacionStock.ToString("dd/MM/yy"));
                    if (esReporteGeneral)
                    {
                        table.Cell().Element(c => CellStyleData(c, isEven)).Text(producto.Vendedor?.CodigoVendedor);
                    }
                    rowIndex++;
                }
            });
        }

        public void GenerarReporteVendedoresPdf(IEnumerable<Vendedor> vendedores, string nombreAdministrador, string reporteId, string tituloReporte)
        {
            if (vendedores == null || !vendedores.Any()) { MessageBox.Show("No hay datos de vendedores para generar el reporte.", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar Reporte de Vendedores PDF";
                saveFileDialog.FileName = $"Reporte_{tituloReporte.Replace(" ", "_")}_{reporteId}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    {
                        try
                        {
                            Document.Create(container =>
                            {
                                container.Page(page =>
                                {
                                    page.Margin(30f, Unit.Point); page.Size(PageSizes.Letter); page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Calibri).FontColor(colorTextoGeneral));
                                    page.Header().Element(headerContainer => ComposeHeader(headerContainer, nombreAdministrador, reporteId, tituloReporte));
                                    page.Content().Element(contentContainer => ComposeVendedoresTable(contentContainer, vendedores));
                                    page.Footer().AlignCenter().Text(text =>
                                    {
                                        var footerStyle = TextStyle.Default.FontSize(8f);
                                        text.CurrentPageNumber().Style(footerStyle);
                                        text.Span(" / ").Style(footerStyle);
                                        text.TotalPages().Style(footerStyle);
                                    });
                                });
                            }).GeneratePdf(saveFileDialog.FileName);
                            MessageBox.Show($"Reporte de vendedores guardado exitosamente en:\n{saveFileDialog.FileName}", "Reporte Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { MessageBox.Show($"Error al generar el PDF de vendedores: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void ComposeVendedoresTable(IContainer container, IEnumerable<Vendedor> vendedores)
        {
            IContainer CellStyleHeader(IContainer c) => c.BorderBottom(1.5f).BorderColor(colorPrimarioDemeter).Padding(6f).Background(colorFondoCabeceraTabla);
            IContainer CellStyleData(IContainer c, bool isEvenRow) => c.BorderBottom(1f).BorderColor(colorBordeTabla).Padding(6f).Background(isEvenRow ? Colors.White : Colors.Grey.Lighten4);

            int rowIndex = 0;
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2.5f);
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(2f);
                    columns.RelativeColumn(2f);
                    columns.RelativeColumn(1f);
                });
                table.Header(header =>
                {
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Nombre Completo").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Código").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Teléfono").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Fec. Registro").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Estado").SemiBold().FontColor(colorTextoTitulos));
                });
                foreach (var vendedor in vendedores)
                {
                    bool isEven = rowIndex % 2 == 0;
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text($"{vendedor.Nombre} {vendedor.Apellido}");
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(vendedor.CodigoVendedor);
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(vendedor.Telefono);
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(vendedor.FechaRegistro.ToString("dd/MM/yyyy"));
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(vendedor.Activo ? "Activo" : "Inactivo");
                    rowIndex++;
                }
            });
        }

        public void GenerarReporteClientesPdf(IEnumerable<Cliente> clientes, string nombreAdministrador, string reporteId, string tituloReporte)
        {
            if (clientes == null || !clientes.Any()) { MessageBox.Show("No hay datos de clientes para generar el reporte.", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar Reporte de Clientes PDF";
                saveFileDialog.FileName = $"Reporte_{tituloReporte.Replace(" ", "_")}_{reporteId}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    {
                        try
                        {
                            Document.Create(container =>
                            {
                                container.Page(page =>
                                {
                                    page.Margin(30f, Unit.Point); page.Size(PageSizes.Letter); page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Calibri).FontColor(colorTextoGeneral));
                                    page.Header().Element(headerContainer => ComposeHeader(headerContainer, nombreAdministrador, reporteId, tituloReporte));
                                    page.Content().Element(contentContainer => ComposeClientesTable(contentContainer, clientes));
                                    page.Footer().AlignCenter().Text(text =>
                                    {
                                        var footerStyle = TextStyle.Default.FontSize(8f);
                                        text.CurrentPageNumber().Style(footerStyle);
                                        text.Span(" / ").Style(footerStyle);
                                        text.TotalPages().Style(footerStyle);
                                    });
                                });
                            }).GeneratePdf(saveFileDialog.FileName);
                            MessageBox.Show($"Reporte de clientes guardado exitosamente en:\n{saveFileDialog.FileName}", "Reporte Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { MessageBox.Show($"Error al generar el PDF de clientes: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void ComposeClientesTable(IContainer container, IEnumerable<Cliente> clientes)
        {
            IContainer CellStyleHeader(IContainer c) => c.BorderBottom(1.5f).BorderColor(colorPrimarioDemeter).Padding(5f).Background(colorFondoCabeceraTabla);
            IContainer CellStyleData(IContainer c, bool isEvenRow) => c.BorderBottom(1f).BorderColor(colorBordeTabla).Padding(5f).Background(isEvenRow ? Colors.White : Colors.Grey.Lighten4);

            int rowIndex = 0;
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2.5f);
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(2f);
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(2.5f);
                    columns.RelativeColumn(1.5f);
                    columns.RelativeColumn(1f);
                });
                table.Header(header =>
                {
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Nombre Completo").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Tipo Doc.").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("N° Documento").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Teléfono").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Email").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Fec. Registro").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeader).Text(text => text.Span("Estado").SemiBold().FontColor(colorTextoTitulos));
                });
                foreach (var cliente in clientes)
                {
                    bool isEven = rowIndex % 2 == 0;
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text($"{cliente.Nombre} {cliente.Apellido}");
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(cliente.TipoDocumento?.Nombre);
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(cliente.NumeroDocumento);
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(cliente.Telefono);
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(cliente.Correo);
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(cliente.FechaRegistro.ToString("dd/MM/yyyy"));
                    table.Cell().Element(c => CellStyleData(c, isEven)).Text(cliente.Activo ? "Activo" : "Inactivo");
                    rowIndex++;
                }
            });
        }


        public void GenerarFacturaVentaPdf(Venta venta, string nombreAdministradorEmisor)
        {
            if (venta == null || venta.DetallesVenta == null || !venta.DetallesVenta.Any() || venta.Cliente == null || venta.Vendedor == null)
            {
                MessageBox.Show("Datos incompletos para generar la factura (venta, detalles, cliente o vendedor faltantes).", "Datos Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar Factura PDF";
                saveFileDialog.FileName = $"Factura_Venta_{venta.IdVenta}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    {
                        try
                        {
                            var document = Document.Create(container =>
                            {
                                container.Page(page =>
                                {
                                    page.Margin(35f, Unit.Point);
                                    page.Size(PageSizes.Letter);
                                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Calibri).FontColor(colorTextoGeneral));

                                    page.Header().Element(headerContainer => ComposeFacturaHeader(headerContainer, venta, nombreAdministradorEmisor));
                                    page.Content().Column(column =>
                                    {
                                        column.Item().Element(contentContainer => ComposeFacturaDetallesParticipantes(contentContainer, venta));
                                        column.Item().PaddingTop(15f).Element(contentContainer => ComposeFacturaItemsTable(contentContainer, venta.DetallesVenta));
                                        column.Item().PaddingTop(15f).Element(contentContainer => ComposeFacturaTotales(contentContainer, venta));
                                    });
                                    page.Footer().AlignCenter().PaddingTop(20f).Text(text =>
                                    {
                                        text.Span("¡Gracias por su compra en Demeter!").Style(TextStyle.Default.FontSize(9f).Italic());
                                    });
                                });
                            });

                            document.GeneratePdf(saveFileDialog.FileName);
                            MessageBox.Show($"Factura guardada exitosamente en:\n{saveFileDialog.FileName}", "Factura Generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al generar la factura PDF: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void ComposeFacturaHeader(IContainer container, Venta venta, string nombreEmisor)
        {
            var titleStyle = TextStyle.Default.FontSize(22).Bold().FontColor(colorPrimarioDemeter);
            var invoiceTitleStyle = TextStyle.Default.FontSize(18).SemiBold().FontColor(Colors.Grey.Darken2);
            var detailStyle = TextStyle.Default.FontSize(9).FontColor(Colors.Grey.Darken1);

            container.Row(row =>
            {
                row.RelativeItem(2).Column(column =>
                {
                    var logoStream = typeof(ReportePdfExporter).Assembly.GetManifestResourceStream("GUI.image.LogoDemeter_ORIGINAL.png");
                    if (logoStream != null)
                    {
                        using (var ms = new MemoryStream())
                        {
                            logoStream.CopyTo(ms);
                            byte[] logoBytes = ms.ToArray();
                            column.Item().Width(110f, Unit.Point).Image(logoBytes);
                        }
                        column.Item().PaddingTop(8f).Text("Demeter Mercado Agrícola").Style(TextStyle.Default.FontSize(15).Bold().FontColor(colorTextoTitulos));
                    }
                    else
                    {
                        column.Item().Text("Demeter").Style(titleStyle);
                    }
                });

                row.RelativeItem(2).AlignRight().Column(column =>
                {
                    column.Item().Text("FACTURA DE VENTA").Style(invoiceTitleStyle);
                    column.Item().Text($"No. {venta.IdVenta:D6}").Style(TextStyle.Default.FontSize(14).SemiBold());
                    column.Spacing(8f);
                    column.Item().Text($"Fecha: {venta.FechaOcurrencia:dd/MM/yyyy HH:mm:ss}").Style(detailStyle);
                    column.Item().Text($"Emitida por: {nombreEmisor}").Style(detailStyle);
                });
            });
            container.PaddingBottom(25f);
            container.LineHorizontal(1.5f).LineColor(colorPrimarioDemeter);
            container.PaddingBottom(15f);
        }

        private void ComposeFacturaDetallesParticipantes(IContainer container, Venta venta)
        {
            var sectionTitleStyle = TextStyle.Default.FontSize(12).Bold().FontColor(colorTextoTitulos).Underline();
            var detailStyle = TextStyle.Default.FontSize(10);
            var labelStyle = detailStyle.SemiBold();

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("DATOS DEL CLIENTE").Style(sectionTitleStyle);
                    column.Spacing(3f);
                    column.Item().Text(text => { text.Span("Nombre: ").Style(labelStyle); text.Span($"{venta.Cliente.Nombre} {venta.Cliente.Apellido}"); });
                    column.Item().Text(text => { text.Span("Documento: ").Style(labelStyle); text.Span($"{venta.Cliente.TipoDocumento?.Nombre} {venta.Cliente.NumeroDocumento}"); });
                    if (!string.IsNullOrWhiteSpace(venta.Cliente.Correo))
                        column.Item().Text(text => { text.Span("Email: ").Style(labelStyle); text.Span(venta.Cliente.Correo); });
                    if (!string.IsNullOrWhiteSpace(venta.Cliente.Telefono))
                        column.Item().Text(text => { text.Span("Teléfono: ").Style(labelStyle); text.Span(venta.Cliente.Telefono); });
                });

                row.ConstantItem(20f);

                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("DATOS DEL VENDEDOR").Style(sectionTitleStyle);
                    column.Spacing(3f);
                    column.Item().Text(text => { text.Span("Nombre: ").Style(labelStyle); text.Span($"{venta.Vendedor.Nombre} {venta.Vendedor.Apellido}"); });
                    column.Item().Text(text => { text.Span("Código: ").Style(labelStyle); text.Span(venta.Vendedor.CodigoVendedor); });
                });
            });
            container.PaddingBottom(20f);
        }

        private void ComposeFacturaItemsTable(IContainer container, ICollection<DetalleVenta> detalles)
        {
            IContainer CellStyleHeaderFactura(IContainer c) => c.BorderBottom(1.5f).BorderColor(colorPrimarioDemeter).PaddingVertical(8f).PaddingHorizontal(5f).Background(colorFondoCabeceraTabla);
            IContainer CellStyleDataFactura(IContainer c, bool isEvenRow) => c.BorderBottom(1f).BorderColor(colorBordeTabla).PaddingVertical(6f).PaddingHorizontal(5f).Background(isEvenRow ? Colors.White : Colors.Grey.Lighten4);

            int rowIndex = 0;
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(4.5f);
                    columns.ConstantColumn(70f);
                    columns.ConstantColumn(100f);
                    columns.ConstantColumn(110f);
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyleHeaderFactura).Text(text => text.Span("Descripción").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeaderFactura).AlignCenter().Text(text => text.Span("Cant.").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeaderFactura).AlignRight().Text(text => text.Span("Vlr. Unit.").SemiBold().FontColor(colorTextoTitulos));
                    header.Cell().Element(CellStyleHeaderFactura).AlignRight().Text(text => text.Span("Subtotal").SemiBold().FontColor(colorTextoTitulos));
                });

                foreach (var item in detalles)
                {
                    bool isEven = rowIndex % 2 == 0;
                    table.Cell().Element(c => CellStyleDataFactura(c, isEven)).Text(item.Producto?.Nombre ?? "Producto no encontrado");
                    table.Cell().Element(c => CellStyleDataFactura(c, isEven)).AlignCenter().Text(item.Cantidad.ToString());
                    table.Cell().Element(c => CellStyleDataFactura(c, isEven)).AlignRight().Text(item.PrecioUnitario.ToString("C"));
                    table.Cell().Element(c => CellStyleDataFactura(c, isEven)).AlignRight().Text(item.TotalLinea.ToString("C"));
                    rowIndex++;
                }
            });
            container.PaddingBottom(15f);
        }

        private void ComposeFacturaTotales(IContainer container, Venta venta)
        {
            var totalLabelStyle = TextStyle.Default.FontSize(11).SemiBold();
            var totalValueStyle = TextStyle.Default.FontSize(11).SemiBold();
            var grandTotalLabelStyle = TextStyle.Default.FontSize(13).Bold().FontColor(colorPrimarioDemeter);
            var grandTotalValueStyle = TextStyle.Default.FontSize(13).Bold().FontColor(colorPrimarioDemeter);

            container.AlignRight().Width(280f, Unit.Point).Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.RelativeItem().Text("Subtotal:").Style(totalLabelStyle);
                    row.ConstantItem(120f).AlignRight().Text(venta.Subtotal.ToString("C")).Style(totalValueStyle);
                });
                column.Item().PaddingTop(3f).Row(row =>
                {
                    row.RelativeItem().Text("Descuento:").Style(totalLabelStyle);
                    row.ConstantItem(120f).AlignRight().Text(venta.Descuento.ToString("C")).Style(totalValueStyle);
                });
                column.Item().PaddingTop(8f).LineHorizontal(1f).LineColor(Colors.Grey.Medium);
                column.Item().PaddingTop(8f).Row(row =>
                {
                    row.RelativeItem().Text("TOTAL A PAGAR:").Style(grandTotalLabelStyle);
                    row.ConstantItem(120f).AlignRight().Text(venta.Total.ToString("C")).Style(grandTotalValueStyle);
                });
            });
            container.PaddingTop(25f);
            container.PaddingBottom(25f);
            container.LineHorizontal(1f).LineColor(Colors.Grey.Lighten1);
            container.PaddingBottom(10f);
            container.AlignCenter().Text("Estado de la Venta: " + (venta.EstadoVenta?.Nombre ?? "Desconocido")).Style(TextStyle.Default.FontSize(9).Italic().FontColor(Colors.Grey.Darken1));
            if (!string.IsNullOrWhiteSpace(venta.Observaciones))
            {
                container.PaddingTop(5f).AlignLeft().Text("Observaciones: " + venta.Observaciones).Style(TextStyle.Default.FontSize(8).Italic().FontColor(Colors.Grey.Darken1));
            }
        }
    }
}