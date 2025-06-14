namespace GqlPlus.Rendering.Simple;

public class DomainLabelRendererTests
  : DomainItemRendererTestBase<DomainLabelModel, EnumLabelInput>
{
  private readonly IRenderer<EnumValueModel> _enumValueRenderer;

  public DomainLabelRendererTests()
  {
    _enumValueRenderer = RFor<EnumValueModel>();
    Renderer = new DomainLabelRenderer(_enumValueRenderer);
  }

  protected override IRenderer<DomainLabelModel> Renderer { get; }

  protected override string[] ItemExpected(EnumLabelInput item, bool excluded)
    => ["!_DomainLabel",
        "exclude: " + excluded.TrueFalse(),
        "value:",
        $"  value: !_EnumValue '{item}'",
        ];
  protected override DomainLabelModel NewItem(EnumLabelInput item, bool excluded)
  {
    RenderReturnsMap(_enumValueRenderer, "_EnumValue", item);
    return new(item.EnumType, item.Label, excluded);
  }
}

public class DomainItemLabelRendererTests
  : DomainAllRendererTestBase<DomainLabelModel, EnumLabelInput>
{
  protected override string[] AllExpected(string name, EnumLabelInput item)
    => ["!_DomainItem(_DomainLabel)",
        "domain: " + name,
        $"value: !_ItemModel '{item}'",
        ];
  protected override DomainLabelModel NewItem(EnumLabelInput item) => new(item.EnumType, item.Label, false);
}

public class DomainEnumRendererTests
  : DomainRendererTestBase<DomainLabelModel, string>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Enum;

  protected override DomainLabelModel NewItem(string item) => new(item, "", false);
}
