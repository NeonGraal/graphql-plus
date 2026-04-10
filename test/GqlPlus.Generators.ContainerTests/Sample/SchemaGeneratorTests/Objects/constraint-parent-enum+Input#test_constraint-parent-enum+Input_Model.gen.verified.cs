//HintName: test_constraint-parent-enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public class testCnstPrntEnumInp
  : GqlpModelBase
  , ItestCnstPrntEnumInp
{
  public ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp>? AsParentCnstPrntEnumInpparentCnstPrntEnumInp { get; set; }
  public ItestCnstPrntEnumInpObject? As_CnstPrntEnumInp { get; set; }
}

public class testCnstPrntEnumInpObject
  : GqlpModelBase
  , ItestCnstPrntEnumInpObject
{

  public testCnstPrntEnumInpObject
    ()
  {
  }
}

public class testRefCnstPrntEnumInp<TType>
  : GqlpModelBase
  , ItestRefCnstPrntEnumInp<TType>
{
  public ItestRefCnstPrntEnumInpObject<TType>? As_RefCnstPrntEnumInp { get; set; }
}

public class testRefCnstPrntEnumInpObject<TType>
  : GqlpModelBase
  , ItestRefCnstPrntEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstPrntEnumInpObject
    ( TType field
    )
  {
    Field = field;
  }
}
