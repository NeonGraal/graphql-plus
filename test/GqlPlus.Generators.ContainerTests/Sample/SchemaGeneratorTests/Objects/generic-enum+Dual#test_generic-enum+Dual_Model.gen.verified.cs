//HintName: test_generic-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public class testGnrcEnumDual
  : GqlpModelImplementationBase
  , ItestGnrcEnumDual
{
  public ItestRefGnrcEnumDual<testEnumGnrcEnumDual>? AsEnumGnrcEnumDualgnrcEnumDual { get; set; }
  public ItestGnrcEnumDualObject? As_GnrcEnumDual { get; set; }
}

public class testGnrcEnumDualObject
  : GqlpModelImplementationBase
  , ItestGnrcEnumDualObject
{

  public testGnrcEnumDualObject
    ()
  {
  }
}

public class testRefGnrcEnumDual<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcEnumDual<TType>
{
  public ItestRefGnrcEnumDualObject<TType>? As_RefGnrcEnumDual { get; set; }
}

public class testRefGnrcEnumDualObject<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcEnumDualObject
    ( TType field
    )
  {
    Field = field;
  }
}
