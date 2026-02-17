//HintName: test_constraint-parent-enum+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public class testCnstPrntEnumOutp
  : GqlpModelImplementationBase
  , ItestCnstPrntEnumOutp
{
  public ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp>? AsParentCnstPrntEnumOutpparentCnstPrntEnumOutp { get; set; }
  public ItestCnstPrntEnumOutpObject? As_CnstPrntEnumOutp { get; set; }
}

public class testCnstPrntEnumOutpObject
  : GqlpModelImplementationBase
  , ItestCnstPrntEnumOutpObject
{

  public testCnstPrntEnumOutpObject()
  {
  }
}

public class testRefCnstPrntEnumOutp<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntEnumOutp<TType>
{
  public ItestRefCnstPrntEnumOutpObject<TType>? As_RefCnstPrntEnumOutp { get; set; }
}

public class testRefCnstPrntEnumOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstPrntEnumOutpObject(TType field)
  {
    Field = field;
  }
}
