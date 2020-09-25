namespace FluentINI.Core
{
  public interface ICanAddSectionCommentOrData
  {
    ICanAddSectionDataOrBuild WithData(string key, string value);
    ICanAddSectionCommentOrData WithSectionComment(string comment);
  }
}
