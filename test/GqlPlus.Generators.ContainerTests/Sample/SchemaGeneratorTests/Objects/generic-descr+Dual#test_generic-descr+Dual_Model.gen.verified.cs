//HintName: test_generic-descr+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Dual;

public class testGnrcDescrDual<TType>
  : GqlpModelBase
  , ItestGnrcDescrDual<TType>
{
  public ItestGnrcDescrDualObject<TType>? As_GnrcDescrDual { get; set; }
}

public class testGnrcDescrDualObject<TType>
  : GqlpModelBase
  , ItestGnrcDescrDualObject<TType>
{
  public TType Field { get; set; }

  public testGnrcDescrDualObject
    ( TType field
    )
  {
    Field = field;
  }
}
