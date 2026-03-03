//HintName: test_parent-field+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}parent-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public class testPrntFieldDual
  : testRefPrntFieldDual
  , ItestPrntFieldDual
{
  public ItestPrntFieldDualObject? As_PrntFieldDual { get; set; }
}

public class testPrntFieldDualObject
  : testRefPrntFieldDualObject
  , ItestPrntFieldDualObject
{
  public decimal Field { get; set; }

  public testPrntFieldDualObject
    ( decimal parent
    , decimal field
    ) : base(parent)
  {
    Field = field;
  }
}

public class testRefPrntFieldDual
  : GqlpModelImplementationBase
  , ItestRefPrntFieldDual
{
  public string? AsString { get; set; }
  public ItestRefPrntFieldDualObject? As_RefPrntFieldDual { get; set; }
}

public class testRefPrntFieldDualObject
  : GqlpModelImplementationBase
  , ItestRefPrntFieldDualObject
{
  public decimal Parent { get; set; }

  public testRefPrntFieldDualObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
