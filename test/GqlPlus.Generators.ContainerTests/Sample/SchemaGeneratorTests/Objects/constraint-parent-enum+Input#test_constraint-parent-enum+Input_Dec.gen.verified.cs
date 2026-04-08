//HintName: test_constraint-parent-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public interface ItestCnstPrntEnumInp
  // No Base because it's Class
{
  ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp>? AsParentCnstPrntEnumInpparentCnstPrntEnumInp { get; }
  ItestCnstPrntEnumInpObject? As_CnstPrntEnumInp { get; }
}

public interface ItestCnstPrntEnumInpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstPrntEnumInp<TType>
  // No Base because it's Class
{
  ItestRefCnstPrntEnumInpObject<TType>? As_RefCnstPrntEnumInp { get; }
}

public interface ItestRefCnstPrntEnumInpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumCnstPrntEnumInp
{
  parentCnstPrntEnumInp = testParentCnstPrntEnumInp.parentCnstPrntEnumInp,
  cnstPrntEnumInp,
}

public enum testParentCnstPrntEnumInp
{
  parentCnstPrntEnumInp,
}
