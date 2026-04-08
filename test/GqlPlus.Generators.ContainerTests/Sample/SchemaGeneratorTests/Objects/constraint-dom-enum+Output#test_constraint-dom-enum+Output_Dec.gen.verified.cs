//HintName: test_constraint-dom-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public interface ItestCnstDomEnumOutp
  // No Base because it's Class
{
  ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp>? AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; }
  ItestCnstDomEnumOutpObject? As_CnstDomEnumOutp { get; }
}

public interface ItestCnstDomEnumOutpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstDomEnumOutp<TType>
  // No Base because it's Class
{
  ItestRefCnstDomEnumOutpObject<TType>? As_RefCnstDomEnumOutp { get; }
}

public interface ItestRefCnstDomEnumOutpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstDomEnumOutp
{
  cnstDomEnumOutp,
  other,
}

public interface ItestJustCnstDomEnumOutp
  : IGqlpDomainEnum
{
}
