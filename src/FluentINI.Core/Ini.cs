using System.Collections.Generic;

namespace FluentINI.Core
{
  public class Ini
  {
    public Dictionary<string, IniSection> Sections { get; } = new Dictionary<string, IniSection> { { "root", new IniSection() } };
  }
}
