//HintName: test_constraint-alt-obj+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public interface ItestCnstAltObjInp
  // No Base because it's Class
{
  ItestRefCnstAltObjInp<ItestAltCnstAltObjInp>? AsRefCnstAltObjInp { get; }
  ItestCnstAltObjInpObject? As_CnstAltObjInp { get; }
}

public interface ItestCnstAltObjInpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstAltObjInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefCnstAltObjInpObject<TRef>? As_RefCnstAltObjInp { get; }
}

public interface ItestRefCnstAltObjInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstAltObjInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstAltObjInpObject? As_PrntCnstAltObjInp { get; }
}

public interface ItestPrntCnstAltObjInpObject
  // No Base because it's Class
{
}

public interface ItestAltCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  ItestAltCnstAltObjInpObject? As_AltCnstAltObjInp { get; }
}

public interface ItestAltCnstAltObjInpObject
  : ItestPrntCnstAltObjInpObject
{
  decimal Alt { get; }
}
