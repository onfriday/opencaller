using AutoMapper;
using System;
using System.Linq;

namespace OpenCaller.Web.SQLServer.Adapters
{
    public sealed class SQLServerTypeAdapter //: ITypeAdapter
    {
        private readonly IMapper _Mapper;

        public SQLServerTypeAdapter()
        {
            //scan all assemblies finding Automapper Profile
            var profiles = AppDomain.CurrentDomain
                                    .GetAssemblies()
                                    .SelectMany(a => a.GetTypes())
                                    .Where(t => t.BaseType == typeof(Profile));

            var _ignore = new[] {
                "AutoMapper.Configuration.MapperConfigurationExpression"
                , "AutoMapper.Configuration.MapperConfigurationExpression+NamedProfile"
            };

            this._Mapper = new MapperConfiguration(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (!_ignore.Contains(item.FullName))
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                }
            }).CreateMapper();
        }

        public TTarget Adapt<TTarget>(object pSource) where TTarget : class, new()
        {
            return this._Mapper.Map<TTarget>(pSource);
        }

        public TTarget Adapt<TSource, TTarget>(TSource pSource)
            where TSource : class
            where TTarget : class, new()
        {
            return this._Mapper.Map<TSource, TTarget>(pSource);
        }
    }
}



