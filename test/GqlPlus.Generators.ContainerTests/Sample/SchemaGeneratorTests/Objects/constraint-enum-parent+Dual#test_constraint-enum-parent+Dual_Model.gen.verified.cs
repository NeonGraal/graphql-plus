//HintName: test_constraint-enum-parent+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public class testCnstEnumPrntDual
  : GqlpModelImplementationBase
  , ItestCnstEnumPrntDual
{
  public ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual>? AsEnumCnstEnumPrntDualcnstEnumPrntDual { get; set; }
  public ItestCnstEnumPrntDualObject? As_CnstEnumPrntDual { get; set; }
}

public class testCnstEnumPrntDualObject
  : GqlpModelImplementationBase
  , ItestCnstEnumPrntDualObject
{

  public testCnstEnumPrntDualObject
    ()
  {
  }
}

public class testRefCnstEnumPrntDual<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumPrntDual<TType>
{
  public ItestRefCnstEnumPrntDualObject<TType>? As_RefCnstEnumPrntDual { get; set; }
}

public class testRefCnstEnumPrntDualObject<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumPrntDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumPrntDualObject
    ( TType field
    )
  {
    Field = field;
  }
}
