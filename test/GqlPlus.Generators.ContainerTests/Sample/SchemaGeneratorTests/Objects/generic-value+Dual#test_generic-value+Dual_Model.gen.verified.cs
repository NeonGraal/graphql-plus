//HintName: test_generic-value+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public class testGnrcValueDual
  : GqlpModelBase
  , ItestGnrcValueDual
{
  public ItestRefGnrcValueDual<testEnumGnrcValueDual>? AsEnumGnrcValueDualgnrcValueDual { get; set; }
  public ItestGnrcValueDualObject? As_GnrcValueDual { get; set; }
}

public class testGnrcValueDualObject
  : GqlpModelBase
  , ItestGnrcValueDualObject
{

  public testGnrcValueDualObject
    ()
  {
  }
}

public class testRefGnrcValueDual<TType>
  : GqlpModelBase
  , ItestRefGnrcValueDual<TType>
{
  public ItestRefGnrcValueDualObject<TType>? As_RefGnrcValueDual { get; set; }
}

public class testRefGnrcValueDualObject<TType>
  : GqlpModelBase
  , ItestRefGnrcValueDualObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcValueDualObject
    ( TType pfield
    )
  {
    Field = pfield;
  }
}
