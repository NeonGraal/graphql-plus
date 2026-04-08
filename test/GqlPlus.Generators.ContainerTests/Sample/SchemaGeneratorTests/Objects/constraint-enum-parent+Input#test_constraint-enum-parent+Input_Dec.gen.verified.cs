//HintName: test_constraint-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public interface ItestCnstEnumPrntInp
  // No Base because it's Class
{
  ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp>? AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; }
  ItestCnstEnumPrntInpObject? As_CnstEnumPrntInp { get; }
}

public interface ItestCnstEnumPrntInpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstEnumPrntInp<TType>
  // No Base because it's Class
{
  ItestRefCnstEnumPrntInpObject<TType>? As_RefCnstEnumPrntInp { get; }
}

public interface ItestRefCnstEnumPrntInpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstEnumPrntInp
{
  parentCnstEnumPrntInp = testParentCnstEnumPrntInp.parentCnstEnumPrntInp,
  cnstEnumPrntInp,
}

public enum testParentCnstEnumPrntInp
{
  parentCnstEnumPrntInp,
}
