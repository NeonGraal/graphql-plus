//HintName: test_constraint-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public class testCnstEnumDual
  : GqlpModelBase
  , ItestCnstEnumDual
{
  public ItestRefCnstEnumDual<testEnumCnstEnumDual>? AsEnumCnstEnumDualcnstEnumDual { get; set; }
  public ItestCnstEnumDualObject? As_CnstEnumDual { get; set; }
}

public class testCnstEnumDualObject
  : GqlpModelBase
  , ItestCnstEnumDualObject
{

  public testCnstEnumDualObject
    ()
  {
  }
}

public class testRefCnstEnumDual<TType>
  : GqlpModelBase
  , ItestRefCnstEnumDual<TType>
{
  public ItestRefCnstEnumDualObject<TType>? As_RefCnstEnumDual { get; set; }
}

public class testRefCnstEnumDualObject<TType>
  : GqlpModelBase
  , ItestRefCnstEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumDualObject
    ( TType field
    )
  {
    Field = field;
  }
}
