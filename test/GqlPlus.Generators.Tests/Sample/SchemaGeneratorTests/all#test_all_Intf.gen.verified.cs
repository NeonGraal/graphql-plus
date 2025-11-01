//HintName: test_all_Intf.gen.cs
// Generated from all.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_all;

public interface ItestGuid
{
}

public interface ItestMany
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}

public interface ItestField
{
  public testField Field { get; set; }
}

public interface ItestFieldField
{
  public ICollection<testString> strings { get; set; }
}

public interface ItestParam
{
  public testString AsString { get; set; }
  public testParam Param { get; set; }
}

public interface ItestParamField
{
  public testMany? afterId { get; set; }
  public testMany beforeId { get; set; }
}

public interface ItestAll
{
  public testString AsString { get; set; }
  public testAll All { get; set; }
}

public interface ItestAllField
{
  public testField items { get; set; }
}
