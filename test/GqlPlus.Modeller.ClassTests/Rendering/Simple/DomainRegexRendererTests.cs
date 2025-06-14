namespace GqlPlus.Rendering.Simple;

public class DomainRegexRendererTests
  : DomainItemRendererTestBase<DomainRegexModel, string>
{
  protected override IRenderer<DomainRegexModel> Renderer { get; }
    = new DomainRegexRenderer();

  protected override string[] ItemExpected(string item, bool excluded)
    => ["!_DomainRegex",
        "exclude: " + excluded.TrueFalse(),
        "pattern: " + item
        ];
  protected override DomainRegexModel NewItem(string item, bool excluded) => new(item, excluded);
}

public class DomainStringRendererTests
  : DomainRendererTestBase<DomainRegexModel, string>
{
  protected override DomainKindModel DomainKind => DomainKindModel.String;

  protected override DomainRegexModel NewItem(string item) => new(item, false);
}
