namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject<TBase, TRef, TField>
  : IGqlpType<TRef>
  where TRef : IGqlpObjectRef
  where TField : IGqlpObjectField<TRef>
{
  IEnumerable<IGqlpTypeParameter> TypeParameters { get; }
  IEnumerable<TField> Fields { get; }
  IEnumerable<IGqlpAlternate<TBase>> Alternates { get; }
}

public interface IGqlpObjectRef
  : IGqlpDescribed
{
  string? TypeName { get; }
  IGqlpDualBase? Dual { get; }
}

public interface IGqlpObjectBase<TBase>
  : IGqlpDescribed
{
  bool IsTypeParameter { get; }
  IEnumerable<TBase> TypeArguments { get; }
}

public interface IGqlpObjectField<TRef>
  : IGqlpAliased, IGqlpModifiers
{
  TRef Type { get; }
}

public interface IGqlpTypeParameter
  : IGqlpDescribed, IGqlpNamed
{ }

public interface IGqlpAlternate<TRef>
{
  TRef Type { get; }
  IEnumerable<IGqlpModifier> Collections { get; } // Optional is invalid
}

public interface IGqlpDual
  : IGqlpObject<IGqlpDualBase, IGqlpObjectRef, IGqlpDualField>
{ }

public interface IGqlpDualBase
  : IGqlpObjectBase<IGqlpDualBase>
{
  string Dual { get; }
}

public interface IGqlpDualField
  : IGqlpObjectField<IGqlpObjectRef>
{ }

public interface IGqlpInput
  : IGqlpObject<IGqlpInputBase, IGqlpInputRef, IGqlpInputField>
{ }

public interface IGqlpInputBase
  : IGqlpObjectBase<IGqlpInputBase>
{
  string Input { get; }
}

public interface IGqlpInputRef
  : IGqlpObjectRef
{
  IGqlpInputBase? Input { get; }
}

public interface IGqlpInputField
  : IGqlpObjectField<IGqlpInputRef>
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpOutput
  : IGqlpObject<IGqlpOutputBase, IGqlpOutputRef, IGqlOutputField>
{ }

public interface IGqlpOutputBase
  : IGqlpObjectBase<IGqlpOutputBase>
{
  string Output { get; }
  string? EnumValue { get; }
}

public interface IGqlpOutputRef
  : IGqlpObjectRef
{
  IGqlpOutputBase? Output { get; }
}

public interface IGqlOutputField
  : IGqlpObjectField<IGqlpOutputRef>
{ }

public interface IGqlpInputParameter
  : IGqlpModifiers
{
  IGqlpInputRef Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
