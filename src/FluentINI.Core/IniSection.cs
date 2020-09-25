using System.Collections.Generic;

namespace FluentINI.Core
{
  public class IniSection
  {
    public List<string> Comments { get; } = new List<string>();
    public Dictionary<string, IniData> Keys { get; } = new Dictionary<string, IniData>();
  }
}
