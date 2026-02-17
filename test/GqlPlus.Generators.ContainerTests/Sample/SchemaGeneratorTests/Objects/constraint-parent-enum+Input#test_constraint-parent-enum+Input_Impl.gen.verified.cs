//HintName: test_constraint-parent-enum+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public class testCnstPrntEnumInp
  : GqlpModelImplementationBase
  , ItestCnstPrntEnumInp
{
  public ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp>? AsParentCnstPrntEnumInpparentCnstPrntEnumInp { get; set; }
  public ItestCnstPrntEnumInpObject? As_CnstPrntEnumInp { get; set; }
}

public class testCnstPrntEnumInpObject
  : GqlpModelImplementationBase
  , ItestCnstPrntEnumInpObject
{

  public testCnstPrntEnumInpObject()
  {
  }
}

public class testRefCnstPrntEnumInp<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntEnumInp<TType>
{
  public ItestRefCnstPrntEnumInpObject<TType>? As_RefCnstPrntEnumInp { get; set; }
}

public class testRefCnstPrntEnumInpObject<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstPrntEnumInpObject(TType field)
  {
    Field = field;
  }
}
