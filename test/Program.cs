using FluentINI.Core;
using System;

namespace test
{
  class Program
  {
    static void Main(string[] args)
    {
      var ini = IniBuilder.CreateIni()
        .WithData("test", "testVal")
        .WithDataComment("test comment please ignore")
        .WithDataComment("another test")
        .WithSection("a new section")
        .WithSectionComment("this is a section")
        .WithData("val1", "some section data")
        .WithData("val2", "more section data")
        .WithDataComment("this is neat");

      Console.WriteLine(ini.Create());
      ;
    }
  }
}
