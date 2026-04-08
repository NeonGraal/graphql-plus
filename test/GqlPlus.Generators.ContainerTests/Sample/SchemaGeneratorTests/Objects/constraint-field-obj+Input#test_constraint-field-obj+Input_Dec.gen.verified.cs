//HintName: test_constraint-field-obj+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public interface ItestCnstFieldObjInp
  : ItestRefCnstFieldObjInp<ItestAltCnstFieldObjInp>
{
  ItestCnstFieldObjInpObject? As_CnstFieldObjInp { get; }
}

public interface ItestCnstFieldObjInpObject
  : ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>
{
}

public interface ItestRefCnstFieldObjInp<TRef>
  // No Base because it's Class
{
  ItestRefCnstFieldObjInpObject<TRef>? As_RefCnstFieldObjInp { get; }
}

public interface ItestRefCnstFieldObjInpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstFieldObjInpObject? As_PrntCnstFieldObjInp { get; }
}

public interface ItestPrntCnstFieldObjInpObject
  // No Base because it's Class
{
}

public interface ItestAltCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  ItestAltCnstFieldObjInpObject? As_AltCnstFieldObjInp { get; }
}

public interface ItestAltCnstFieldObjInpObject
  : ItestPrntCnstFieldObjInpObject
{
  decimal Alt { get; }
}
