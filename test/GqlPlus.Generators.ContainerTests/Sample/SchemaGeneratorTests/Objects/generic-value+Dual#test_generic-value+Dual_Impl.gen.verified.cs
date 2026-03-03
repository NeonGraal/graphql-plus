//HintName: test_generic-value+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public class testGnrcValueDual
  : GqlpModelImplementationBase
  , ItestGnrcValueDual
{
  public ItestRefGnrcValueDual<testEnumGnrcValueDual>? AsEnumGnrcValueDualgnrcValueDual { get; set; }
  public ItestGnrcValueDualObject? As_GnrcValueDual { get; set; }
}

public class testGnrcValueDualObject
  : GqlpModelImplementationBase
  , ItestGnrcValueDualObject
{

  public testGnrcValueDualObject
    ()
  {
  }
}

public class testRefGnrcValueDual<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcValueDual<TType>
{
  public ItestRefGnrcValueDualObject<TType>? As_RefGnrcValueDual { get; set; }
}

public class testRefGnrcValueDualObject<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcValueDualObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcValueDualObject
    ( TType field
    )
  {
    Field = field;
  }
}
