using System.Collections.Generic;

namespace FluentINI.Core
{
  public class IniData
  {
    public List<string> Comments { get; } = new List<string>();
    public string Value { get; set; }
    public IniData(string value)
    {
      Value = value;
    }
  }
}
