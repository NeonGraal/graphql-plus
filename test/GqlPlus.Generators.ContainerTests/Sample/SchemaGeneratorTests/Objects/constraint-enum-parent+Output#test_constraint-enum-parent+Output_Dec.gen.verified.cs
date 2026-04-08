//HintName: test_constraint-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public interface ItestCnstEnumPrntOutp
  // No Base because it's Class
{
  ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp>? AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; }
  ItestCnstEnumPrntOutpObject? As_CnstEnumPrntOutp { get; }
}

public interface ItestCnstEnumPrntOutpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstEnumPrntOutp<TType>
  // No Base because it's Class
{
  ItestRefCnstEnumPrntOutpObject<TType>? As_RefCnstEnumPrntOutp { get; }
}

public interface ItestRefCnstEnumPrntOutpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstEnumPrntOutp
{
  parentCnstEnumPrntOutp = testParentCnstEnumPrntOutp.parentCnstEnumPrntOutp,
  cnstEnumPrntOutp,
}

public enum testParentCnstEnumPrntOutp
{
  parentCnstEnumPrntOutp,
}
