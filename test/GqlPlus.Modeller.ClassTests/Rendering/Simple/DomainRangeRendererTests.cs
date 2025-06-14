namespace GqlPlus.Rendering.Simple;

public class DomainRangeRendererTests
  : DomainItemRendererTestBase<DomainRangeModel, DomainRangeInput>
{
  protected override IRenderer<DomainRangeModel> Renderer { get; }
    = new DomainRangeRenderer();

  protected override string[] ItemExpected(DomainRangeInput item, bool excluded)
    => ["!_DomainRange",
        "exclude: " + excluded.TrueFalse(),
        $"from: {item.Lower:0.#####}",
        $"to: {item.Upper:0.#####}"
        ];

  protected override DomainRangeModel NewItem(DomainRangeInput item, bool excluded) => new(item.Lower, item.Upper, excluded);
}

public class DomainItemRangeRendererTests
  : DomainAllRendererTestBase<DomainRangeModel, DomainRangeInput>
{
  protected override string[] AllExpected(string name, DomainRangeInput item)
    => ["!_DomainItem(_DomainRange)",
        "domain: " + name,
        $"value: !_ItemModel '{item}'"
        ];

  protected override DomainRangeModel NewItem(DomainRangeInput item) => new(item.Lower, item.Upper, false);
}

public class DomainNumberRendererTests
  : DomainRendererTestBase<DomainRangeModel, DomainRangeInput>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Number;

  protected override DomainRangeModel NewItem(DomainRangeInput item) => new(item.Lower, item.Upper, false);
}
