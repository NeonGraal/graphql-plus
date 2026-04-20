//HintName: test_generic-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public class testGnrcEnumDual
  : GqlpModelBase
  , ItestGnrcEnumDual
{
  public ItestRefGnrcEnumDual<testEnumGnrcEnumDual>? AsEnumGnrcEnumDualgnrcEnumDual { get; set; }
  public ItestGnrcEnumDualObject? As_GnrcEnumDual { get; set; }
}

public class testGnrcEnumDualObject
  : GqlpModelBase
  , ItestGnrcEnumDualObject
{

  public testGnrcEnumDualObject
    ()
  {
  }
}

public class testRefGnrcEnumDual<TType>
  : GqlpModelBase
  , ItestRefGnrcEnumDual<TType>
{
  public ItestRefGnrcEnumDualObject<TType>? As_RefGnrcEnumDual { get; set; }
}

public class testRefGnrcEnumDualObject<TType>
  : GqlpModelBase
  , ItestRefGnrcEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcEnumDualObject
    ( TType pfield
    )
  {
    Field = pfield;
  }
}
