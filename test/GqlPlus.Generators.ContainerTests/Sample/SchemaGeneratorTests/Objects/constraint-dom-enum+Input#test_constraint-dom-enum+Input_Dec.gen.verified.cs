//HintName: test_constraint-dom-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public interface ItestCnstDomEnumInp
  // No Base because it's Class
{
  ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp>? AsEnumCnstDomEnumInpcnstDomEnumInp { get; }
  ItestCnstDomEnumInpObject? As_CnstDomEnumInp { get; }
}

public interface ItestCnstDomEnumInpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstDomEnumInp<TType>
  // No Base because it's Class
{
  ItestRefCnstDomEnumInpObject<TType>? As_RefCnstDomEnumInp { get; }
}

public interface ItestRefCnstDomEnumInpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstDomEnumInp
{
  cnstDomEnumInp,
  other,
}

public interface ItestJustCnstDomEnumInp
  : IGqlpDomainEnum
{
}
