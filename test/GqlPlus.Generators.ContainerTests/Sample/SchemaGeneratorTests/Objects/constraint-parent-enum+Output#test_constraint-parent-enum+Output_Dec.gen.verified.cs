//HintName: test_constraint-parent-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public interface ItestCnstPrntEnumOutp
  // No Base because it's Class
{
  ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp>? AsParentCnstPrntEnumOutpparentCnstPrntEnumOutp { get; }
  ItestCnstPrntEnumOutpObject? As_CnstPrntEnumOutp { get; }
}

public interface ItestCnstPrntEnumOutpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstPrntEnumOutp<TType>
  // No Base because it's Class
{
  ItestRefCnstPrntEnumOutpObject<TType>? As_RefCnstPrntEnumOutp { get; }
}

public interface ItestRefCnstPrntEnumOutpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstPrntEnumOutp
{
  parentCnstPrntEnumOutp = testParentCnstPrntEnumOutp.parentCnstPrntEnumOutp,
  cnstPrntEnumOutp,
}

public enum testParentCnstPrntEnumOutp
{
  parentCnstPrntEnumOutp,
}
