using System;
using System.Linq;
using System.Text;

namespace FluentINI.Core
{
  public class IniBuilder : ICanAddDataOrSection, ICanAddSectionDataOrBuild, ICanAddSectionCommentOrData
  {
    private string _activeSection = "root";
    private string _activeData;
    private readonly Ini _ini;

    private IniBuilder()
    {
      _ini = new Ini();
    }

    public static ICanAddDataOrSection CreateIni()
    {
      return new IniBuilder();
    }

    public ICanAddSectionDataOrBuild WithData(string key, string value)
    {
      _activeData = key;
      if (_ini.Sections[_activeSection].Keys.ContainsKey(key))
      {
        _ini.Sections[_activeSection].Keys[key].Value = value;
      }
      else
      {
        _ini.Sections[_activeSection].Keys.Add(key, new IniData(value));
      }
      return this;
    }

    public ICanAddSectionCommentOrData WithSection(string sectionName)
    {
      _activeSection = sectionName;
      if (!_ini.Sections.ContainsKey(sectionName))
      {
        _ini.Sections.Add(sectionName, new IniSection());
      }
      return this;
    }

    public ICanAddSectionDataOrBuild WithDataComment(string comment)
    {
      _ini.Sections[_activeSection].Keys[_activeData].Comments.Add(comment);
      return this;
    }

    public ICanAddSectionCommentOrData WithSectionComment(string comment)
    {
      _ini.Sections[_activeSection].Comments.Add(comment);
      return this;
    }

    public string Create()
    {
      var sb = new StringBuilder();

      if (_ini.Sections["root"].Keys.Count > 0)
      {
        foreach (var data in _ini.Sections["root"].Keys)
        {
          foreach (var comment in data.Value.Comments.Select(x => $";{x}"))
          {
            sb.AppendLine(comment);
          }
          sb.AppendLine($"{data.Key}={data.Value.Value}");
        }
        sb.AppendLine();
      }

      foreach (var section in _ini.Sections.Where(x => x.Key != "root"))
      {
        foreach (var comment in section.Value.Comments.Select(x => $";{x}"))
        {
          sb.AppendLine(comment);
        }
        sb.AppendLine($"[{section.Key}]");

        foreach (var data in _ini.Sections[section.Key].Keys)
        {
          foreach (var comment in data.Value.Comments.Select(x => $";{x}"))
          {
            sb.AppendLine(comment);
          }
          sb.AppendLine($"{data.Key}={data.Value.Value}");
        }
        sb.AppendLine();
      }

      return sb.ToString();
    }
  }
}
