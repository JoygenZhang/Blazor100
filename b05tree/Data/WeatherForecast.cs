using BootstrapBlazor.Components;
using FreeSql.DataAnnotations;
using System.ComponentModel;

namespace b05tree.Data;

[AutoGenerateClass(Searchable = true, Filterable = true, Sortable = true)] //BB�Զ���������,������,�ɹ���,������
public class WeatherForecast
{
    [Column(IsIdentity = true)] //FreeSql ORM����: ����,��һ������ID���Զ�Ϊ����
    [DisplayName("���")] //BBʹ��DisplayName��Ⱦ����
    public int ID { get; set; }

    [DisplayName("����")]
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}