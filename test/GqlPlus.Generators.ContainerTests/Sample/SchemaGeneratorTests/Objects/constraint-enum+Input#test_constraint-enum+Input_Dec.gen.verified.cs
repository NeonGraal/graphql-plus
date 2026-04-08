//HintName: test_constraint-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public interface ItestCnstEnumInp
  // No Base because it's Class
{
  ItestRefCnstEnumInp<testEnumCnstEnumInp>? AsEnumCnstEnumInpcnstEnumInp { get; }
  ItestCnstEnumInpObject? As_CnstEnumInp { get; }
}

public interface ItestCnstEnumInpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstEnumInp<TType>
  // No Base because it's Class
{
  ItestRefCnstEnumInpObject<TType>? As_RefCnstEnumInp { get; }
}

public interface ItestRefCnstEnumInpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstEnumInp
{
  cnstEnumInp,
}
