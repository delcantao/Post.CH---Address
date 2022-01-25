// See https://service.post.ch/zopa/dlc/app/?service=dlc-web&_ga=2.250430150.1902517967.1643119700-584573197.1641547608&inMobileApp=false&inIframe=false&lang=de#!/main for more information

var fullPath = @"C:\Users\feedc\Downloads\Post_Adressdaten-20220118\Post_Adressdaten20220118.csv";
var fileRecords = await File.ReadAllLinesAsync(fullPath, System.Text.Encoding.Latin1);
var filePath = Path.GetDirectoryName(fullPath) ?? "";
var fileName = Path.GetFileName(fullPath);
var dicList = new Dictionary<string, List<string>>();

for (int i = 0; i < fileRecords.Length - 1; i++)
{
    var line = fileRecords[i];
    var array = line.Split(';');

    if (!dicList.ContainsKey(array[0])) dicList.Add(array[0], new List<string>());

    dicList[array[0]].Add(line);
     
}
foreach (var item in dicList)
{
    File.WriteAllLines(Path.Combine(filePath, item.Key + "_" + fileName), item.Value, System.Text.Encoding.Latin1);
}
