import{j as d,A as c,l as S,m as b,_ as x,u as I,b as C,i as p,o as i,c as l,a as s,t as _,n as B,F as m,r as y,P as u,f as P,p as A,g as F,h as k}from"./index.f19533dd.js";class N{async getProfile(r){const o=await d.get(`api/profiles/${r}`);console.log(o.data),c.activeProfile=o.data}async getProfileKeeps(r){const o=await d.get(`api/profiles/${r}/keeps`);c.keeps=o.data.map(e=>new S(e))}async getProfileVaults(r){const o=await d.get(`api/profiles/${r}/vaults`);c.vaults=o.data.map(e=>new b(e))}}const f=new N;const j={setup(){const t=I();async function r(){try{await f.getProfile(t.params.id)}catch(a){console.error("[]",a),u.error(a)}}async function o(){try{await f.getProfileVaults(t.params.id)}catch(a){console.error("[]",a),u.error(a)}}async function e(){try{await f.getProfileKeeps(t.params.id)}catch(a){console.error("[]",a),u.error(a)}}return C(()=>{r(),e(),o()}),{profile:p(()=>c.activeProfile),keeps:p(()=>c.keeps),vaults:p(()=>c.vaults)}}},w=t=>(A("data-v-1155022c"),t=t(),F(),t),z={class:"container pt-4"},D={class:"info mb-5"},E=["src"],L={class:"fs-1"},M={class:"stuff"},R={class:"container-fluid"},$=w(()=>s("h3",null,"Vaults",-1)),q={class:"container vaults mt-5"},G={class:"d-flex"},H=w(()=>s("h3",{class:"mt-5"},"Keeps",-1)),J={class:"container"},O={class:"masonry my-3"};function Q(t,r,o,e,a,T){var h,v,g;const V=k("VaultCard"),K=k("KeepCard");return i(),l("div",z,[s("div",{class:"col-8 about text-center cover container rounded-5",style:B({backgroundImage:`url(${(h=e.profile)==null?void 0:h.coverImg})`})},[s("div",D,[s("img",{class:"rounded-circle border border-white border-3",height:"100",width:"100",src:(v=e.profile)==null?void 0:v.picture,alt:""},null,8,E),s("h1",null,_((g=e.profile)==null?void 0:g.name),1),s("p",L,_(e.vaults.length)+" Vaults | "+_(e.keeps.length)+" Keeps ",1)])],4),s("div",M,[s("div",R,[$,s("section",q,[s("div",G,[(i(!0),l(m,null,y(e.vaults,n=>(i(),l("div",{key:n.id},[P(V,{vault:n},null,8,["vault"])]))),128))])])]),H,s("section",J,[s("div",O,[(i(!0),l(m,null,y(e.keeps,n=>(i(),l("div",{key:n.id},[P(K,{keep:n},null,8,["keep"])]))),128))])])])])}const W=x(j,[["render",Q],["__scopeId","data-v-1155022c"]]);export{W as default};