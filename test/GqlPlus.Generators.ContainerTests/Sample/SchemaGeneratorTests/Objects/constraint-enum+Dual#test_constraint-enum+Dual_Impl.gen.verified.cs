//HintName: test_constraint-enum+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public class testCnstEnumDual
  : GqlpModelImplementationBase
  , ItestCnstEnumDual
{
  public ItestRefCnstEnumDual<testEnumCnstEnumDual>? AsEnumCnstEnumDualcnstEnumDual { get; set; }
  public ItestCnstEnumDualObject? As_CnstEnumDual { get; set; }
}

public class testCnstEnumDualObject
  : GqlpModelImplementationBase
  , ItestCnstEnumDualObject
{

  public testCnstEnumDualObject()
  {
  }
}

public class testRefCnstEnumDual<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumDual<TType>
{
  public ItestRefCnstEnumDualObject<TType>? As_RefCnstEnumDual { get; set; }
}

public class testRefCnstEnumDualObject<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumDualObject(TType field)
  {
    Field = field;
  }
}
