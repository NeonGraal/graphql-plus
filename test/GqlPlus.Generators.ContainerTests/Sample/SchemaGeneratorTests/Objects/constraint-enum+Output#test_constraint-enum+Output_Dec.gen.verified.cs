//HintName: test_constraint-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public interface ItestCnstEnumOutp
  // No Base because it's Class
{
  ItestRefCnstEnumOutp<testEnumCnstEnumOutp>? AsEnumCnstEnumOutpcnstEnumOutp { get; }
  ItestCnstEnumOutpObject? As_CnstEnumOutp { get; }
}

public interface ItestCnstEnumOutpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstEnumOutp<TType>
  // No Base because it's Class
{
  ItestRefCnstEnumOutpObject<TType>? As_RefCnstEnumOutp { get; }
}

public interface ItestRefCnstEnumOutpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstEnumOutp
{
  cnstEnumOutp,
}
