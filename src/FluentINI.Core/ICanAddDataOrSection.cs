namespace FluentINI.Core
{
  public interface ICanAddDataOrSection
  {
    ICanAddSectionCommentOrData WithSection(string sectionName);
    ICanAddSectionDataOrBuild WithData(string key, string value);
  }
}
