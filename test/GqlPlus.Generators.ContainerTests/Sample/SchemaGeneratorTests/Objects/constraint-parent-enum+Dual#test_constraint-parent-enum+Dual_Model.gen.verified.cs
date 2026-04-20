//HintName: test_constraint-parent-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public class testCnstPrntEnumDual
  : GqlpModelBase
  , ItestCnstPrntEnumDual
{
  public ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual>? AsParentCnstPrntEnumDualparentCnstPrntEnumDual { get; set; }
  public ItestCnstPrntEnumDualObject? As_CnstPrntEnumDual { get; set; }
}

public class testCnstPrntEnumDualObject
  : GqlpModelBase
  , ItestCnstPrntEnumDualObject
{

  public testCnstPrntEnumDualObject
    ()
  {
  }
}

public class testRefCnstPrntEnumDual<TType>
  : GqlpModelBase
  , ItestRefCnstPrntEnumDual<TType>
{
  public ItestRefCnstPrntEnumDualObject<TType>? As_RefCnstPrntEnumDual { get; set; }
}

public class testRefCnstPrntEnumDualObject<TType>
  : GqlpModelBase
  , ItestRefCnstPrntEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstPrntEnumDualObject
    ( TType pfield
    )
  {
    Field = pfield;
  }
}
