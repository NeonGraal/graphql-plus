//HintName: test_constraint-alt+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Dual;

public class testCnstAltDual<TType>
  : GqlpModelBase
  , ItestCnstAltDual<TType>
{
  public TType? Astype { get; set; }
  public ItestCnstAltDualObject<TType>? As_CnstAltDual { get; set; }
}

public class testCnstAltDualObject<TType>
  : GqlpModelBase
  , ItestCnstAltDualObject<TType>
{

  public testCnstAltDualObject
    ()
  {
  }
}
