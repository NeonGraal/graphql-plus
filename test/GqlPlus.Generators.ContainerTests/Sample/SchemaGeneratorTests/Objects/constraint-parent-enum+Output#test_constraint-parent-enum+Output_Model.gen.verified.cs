//HintName: test_constraint-parent-enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public class testCnstPrntEnumOutp
  : GqlpModelBase
  , ItestCnstPrntEnumOutp
{
  public ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp>? AsParentCnstPrntEnumOutpparentCnstPrntEnumOutp { get; set; }
  public ItestCnstPrntEnumOutpObject? As_CnstPrntEnumOutp { get; set; }
}

public class testCnstPrntEnumOutpObject
  : GqlpModelBase
  , ItestCnstPrntEnumOutpObject
{

  public testCnstPrntEnumOutpObject
    ()
  {
  }
}

public class testRefCnstPrntEnumOutp<TType>
  : GqlpModelBase
  , ItestRefCnstPrntEnumOutp<TType>
{
  public ItestRefCnstPrntEnumOutpObject<TType>? As_RefCnstPrntEnumOutp { get; set; }
}

public class testRefCnstPrntEnumOutpObject<TType>
  : GqlpModelBase
  , ItestRefCnstPrntEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstPrntEnumOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
