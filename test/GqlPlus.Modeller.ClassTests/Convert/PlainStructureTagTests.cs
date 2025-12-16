namespace GqlPlus.Convert;

public class PlainStructureTagTests()
  : PlainStructureTests
{
  protected override string ValueTag => "value";
  protected override string MapTag => "map";
  protected override string ListTag => "list";
  protected override string KeyTag => "key";
}
