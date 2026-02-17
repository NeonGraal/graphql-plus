//HintName: test_generic-field+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Dual;

public class testGnrcFieldDual<TType>
  : GqlpModelImplementationBase
  , ItestGnrcFieldDual<TType>
{
  public ItestGnrcFieldDualObject<TType>? As_GnrcFieldDual { get; set; }
}

public class testGnrcFieldDualObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcFieldDualObject<TType>
{
  public TType Field { get; set; }

  public testGnrcFieldDualObject(TType field)
  {
    Field = field;
  }
}
