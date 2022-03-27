using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using b03sqlite.Data;
using b03sqlite.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddFreeSql(option =>
{
    option.UseConnectionString(FreeSql.DataType.Sqlite, "Data Source=test.db;")  //Ҳ����д�������ļ���
#if DEBUG
         //��������:�Զ�ͬ��ʵ��
         .UseAutoSyncStructure(true)
         .UseNoneCommandParameter(true)
         //����sql������
         .UseMonitorCommand(cmd => System.Console.WriteLine(cmd.CommandText))
#endif
    ;
});
builder.Services.AddBootstrapBlazor();
builder.Services.AddTransient<ImportExportsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
