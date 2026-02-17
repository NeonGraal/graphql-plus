//HintName: test_constraint-parent-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public interface ItestCnstPrntEnumOutp
  : IGqlpModelImplementationBase
{
  ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp> AsParentCnstPrntEnumOutpparentCnstPrntEnumOutp { get; }
  ItestCnstPrntEnumOutpObject AsCnstPrntEnumOutp { get; }
}

public interface ItestCnstPrntEnumOutpObject
{
}

public interface ItestRefCnstPrntEnumOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstPrntEnumOutpObject<TType> AsRefCnstPrntEnumOutp { get; }
}

public interface ItestRefCnstPrntEnumOutpObject<TType>
{
  TType Field { get; }
}
