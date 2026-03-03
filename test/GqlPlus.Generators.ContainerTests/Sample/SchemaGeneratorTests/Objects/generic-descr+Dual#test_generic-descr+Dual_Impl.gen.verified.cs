//HintName: test_generic-descr+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Dual;

public class testGnrcDescrDual<TType>
  : GqlpModelImplementationBase
  , ItestGnrcDescrDual<TType>
{
  public ItestGnrcDescrDualObject<TType>? As_GnrcDescrDual { get; set; }
}

public class testGnrcDescrDualObject<TType>
  : GqlpModelImplementationBase
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
