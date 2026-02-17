//HintName: test_all_Impl.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

public class testGuid
  : GqlpDomainString
  , ItestGuid
{
}

public class testMany
  : GqlpModelImplementationBase
  , ItestMany
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}

public class testField
  : ItestField
{
  public ICollection<string> Strings { get; set; }
}

public class testParam
  : ItestParam
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }
}

public class testAll
  : ItestAll
{
  public ItestField Items (ItestParam?)
{ }
}
