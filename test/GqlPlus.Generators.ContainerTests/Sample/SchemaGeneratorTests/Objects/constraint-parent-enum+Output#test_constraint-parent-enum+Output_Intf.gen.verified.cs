//HintName: test_constraint-parent-enum+Output_Intf.gen.cs
// Generated from constraint-parent-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public interface ItestCnstPrntEnumOutp
{
  ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp> AsRefCnstPrntEnumOutp { get; }
  ItestCnstPrntEnumOutpObject AsCnstPrntEnumOutp { get; }
}

public interface ItestCnstPrntEnumOutpObject
{
}

public interface ItestRefCnstPrntEnumOutp<TType>
{
  ItestRefCnstPrntEnumOutpObject AsRefCnstPrntEnumOutp { get; }
}

public interface ItestRefCnstPrntEnumOutpObject<TType>
{
  TType Field { get; }
}
