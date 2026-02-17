//HintName: test_constraint-alt+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Dual;

public class testCnstAltDual<TType>
  : GqlpModelImplementationBase
  , ItestCnstAltDual<TType>
{
  public TType? Astype { get; set; }
  public ItestCnstAltDualObject<TType>? As_CnstAltDual { get; set; }
}

public class testCnstAltDualObject<TType>
  : GqlpModelImplementationBase
  , ItestCnstAltDualObject<TType>
{

  public testCnstAltDualObject()
  {
  }
}
