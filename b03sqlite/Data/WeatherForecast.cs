using BootstrapBlazor.Components;
using FreeSql.DataAnnotations;
using System.ComponentModel;
using Magicodes.ExporterAndImporter.Excel;
using OfficeOpenXml.Table;

namespace b03sqlite.Data;

[ExcelImporter(IsLabelingError = true)]
[ExcelExporter(Name = "������Ʒ�м��", TableStyle = TableStyles.Light10, AutoFitAllColumn = true)]
[AutoGenerateClass(Searchable = true, Filterable = true, Sortable = true)]
public class WeatherForecast
{
    [Column(IsIdentity = true)]
    [DisplayName("���")]
    public int ID { get; set; }

    [DisplayName("����")]
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
