namespace FluentINI.Core
{
  public interface ICanAddSectionDataOrBuild
  {
    ICanAddSectionCommentOrData WithSection(string sectionName);
    ICanAddSectionDataOrBuild WithData(string key, string value);
    ICanAddSectionDataOrBuild WithDataComment(string comment);
    string Create();
  }
}
