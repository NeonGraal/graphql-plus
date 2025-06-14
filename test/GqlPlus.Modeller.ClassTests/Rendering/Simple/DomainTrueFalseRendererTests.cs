namespace GqlPlus.Rendering.Simple;

public class DomainTrueFalseRendererTests
  : DomainItemRendererTestBase<DomainTrueFalseModel, bool>
{
  protected override IRenderer<DomainTrueFalseModel> Renderer { get; }
    = new DomainTrueFalseRenderer();

  protected override string[] ItemExpected(bool item, bool excluded)
    => ["!_DomainTrueFalse",
        "exclude: " + excluded.TrueFalse(),
        "value: " + item.TrueFalse()
        ];
  protected override DomainTrueFalseModel NewItem(bool item, bool excluded) => new(item, excluded);
}

public class DomainBooleanRendererTests
  : DomainRendererTestBase<DomainTrueFalseModel, bool>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Boolean;

  protected override DomainTrueFalseModel NewItem(bool item) => new(item, false);
}
