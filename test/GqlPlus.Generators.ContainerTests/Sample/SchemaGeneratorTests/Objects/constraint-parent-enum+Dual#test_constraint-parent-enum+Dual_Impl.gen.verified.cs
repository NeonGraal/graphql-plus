//HintName: test_constraint-parent-enum+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public class testCnstPrntEnumDual
  : GqlpModelImplementationBase
  , ItestCnstPrntEnumDual
{
  public ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual>? AsParentCnstPrntEnumDualparentCnstPrntEnumDual { get; set; }
  public ItestCnstPrntEnumDualObject? As_CnstPrntEnumDual { get; set; }
}

public class testCnstPrntEnumDualObject
  : GqlpModelImplementationBase
  , ItestCnstPrntEnumDualObject
{

  public testCnstPrntEnumDualObject
    ()
  {
  }
}

public class testRefCnstPrntEnumDual<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntEnumDual<TType>
{
  public ItestRefCnstPrntEnumDualObject<TType>? As_RefCnstPrntEnumDual { get; set; }
}

public class testRefCnstPrntEnumDualObject<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstPrntEnumDualObject
    ( TType field
    )
  {
    Field = field;
  }
}
