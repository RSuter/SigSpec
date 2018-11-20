﻿using NJsonSchema;
using NJsonSchema.CodeGeneration;
using SigSpec.Core;
using System;

namespace SigSpec.CodeGeneration.Models
{
    public class ParameterModel
    {
        private readonly string _name;
        private readonly SigSpecParameter _parameter;
        private readonly TypeResolverBase _resolver;
        private readonly Lazy<string> _type;

        public ParameterModel(string name, SigSpecParameter parameter, TypeResolverBase resolver)
        {
            _name = name;
            _parameter = parameter;
            _resolver = resolver;
            _type = new Lazy<string>(() => _resolver.Resolve(_parameter.ActualTypeSchema, _parameter.IsNullable(SchemaType.JsonSchema), _name));
        }

        public string Name => _name;

        public string Type => _type.Value;
    }
}
