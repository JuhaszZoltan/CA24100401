using CA24100401;
using System.Text;

const int AktEv = 2014;
List<Versenyzo> versenyzok = [];

using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"versenyzok szama: {versenyzok.Count}");

var f1 = versenyzok.Count(v => v.Kategoria == "elit");
Console.WriteLine($"versenyzok szama elit kategoriaban: {f1} fo");

var f2 = versenyzok.Where(v => !v.Nem).Average(v => AktEv - v.Szul);
Console.WriteLine($"noi versenyzok atlageletkora: {f2:0.00} ev");

var f3 = versenyzok.Sum(v => v.Versenyidok["kerékpár"].TotalHours);
Console.WriteLine($"kerekparozassal toltott osszido: {f3:0.00} ora");

var f4 = versenyzok.Where(v => v.Kategoria == "elit junior")
    .Average(v => v.Versenyidok["úszás"].TotalMinutes);
Console.WriteLine($"elit juniorok atlagos uszasi ideje: {f4:0.00} perc");

var f5 = versenyzok.Where(v => v.Nem).MinBy(v => v.OsszIdoSec);
Console.WriteLine($"ferfi gyoztes: {f5}");

var f6 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key);
Console.WriteLine("versenyt befejezok szama (kategoria, fo, depo ido):");
foreach (var grp in f6) Console.WriteLine(
    $"{grp.Key,11}: " +
    $"{grp.Count(),2} fo   " +
    $"{grp.Average(
        v => v.Versenyidok["I. depó"].TotalMinutes 
        + v.Versenyidok["II. depó"].TotalMinutes):00.000} sec");

